using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostService.Data;
using PostService.DTOs;
using PostService.Entities;

namespace PostService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public PostsController(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<PostDto>>> GetAllPosts()
    {
        var posts = await _context.Posts
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();

        return _mapper.Map<List<PostDto>>(posts);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PostDto>> GetPostById(Guid id)
    {
        var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);

        if (post == null) return NotFound();

        return _mapper.Map<PostDto>(post);
    }   

    [HttpPost]
    public async Task<ActionResult<PostDto>> CreatePost(CreatePostDto createPostDto)
    {
        var post = _mapper.Map<Post>(createPostDto);

        post.Author = "Anonymous";
        
        _context.Posts.Add(post);

        var result = await _context.SaveChangesAsync() > 0;

        if (!result) return BadRequest("Failed to create post");

        return CreatedAtAction(nameof(GetPostById), new { id = post.Id }, _mapper.Map<PostDto>(post));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PostDto>> UpdatePost(Guid id, UpdatePostDto updatePostDto)
    {
        var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);

        if (post == null) return NotFound();

        post.Title = updatePostDto.Title ?? post.Title;
        post.Content = updatePostDto.Content ?? post.Content;
        post.ImageUrl = updatePostDto.ImageUrl ?? post.ImageUrl;
        post.UpdatedAt = DateTime.UtcNow;

        var result = await _context.SaveChangesAsync() > 0;

        if (!result) return BadRequest("Failed to update post");

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePost(Guid id)
    {
        var post = await _context.Posts.FindAsync(id);

        if (post == null) return NotFound();

        _context.Posts.Remove(post);

        var result = await _context.SaveChangesAsync() > 0;

        if (!result) return BadRequest("Failed to delete post");

        return Ok();
    }





}
